# Run performance benchmark script
# This script tests the performance of the GameStatistics endpoint

param (
    [string]$apiUrl = "http://localhost:5000/api/statistics/game/1/details",
    [int]$iterations = 10
)

Write-Host "Starting performance benchmark test..."
Write-Host "Testing API URL: $apiUrl"
Write-Host "Running $iterations iterations..."

$totalTime = 0
$minTime = [double]::MaxValue
$maxTime = 0

for ($i = 1; $i -le $iterations; $i++) {
    Write-Host "Running iteration $i of $iterations..."
    
    $startTime = Get-Date
    
    try {
        $response = Invoke-WebRequest -Uri $apiUrl -Method Get -UseBasicParsing
        $statusCode = $response.StatusCode
        
        $endTime = Get-Date
        $executionTime = ($endTime - $startTime).TotalMilliseconds
        
        $totalTime += $executionTime
        
        if ($executionTime -lt $minTime) {
            $minTime = $executionTime
        }
        
        if ($executionTime -gt $maxTime) {
            $maxTime = $executionTime
        }
        
        Write-Host "  Request completed in $executionTime ms with status code $statusCode"
    }
    catch {
        Write-Host "  Error: $_" -ForegroundColor Red
    }
    
    # Add a small delay between requests
    Start-Sleep -Milliseconds 500
}

$avgTime = $totalTime / $iterations

Write-Host "`nBenchmark Results:"
Write-Host "----------------"
Write-Host "Total iterations: $iterations"
Write-Host "Average response time: $avgTime ms"
Write-Host "Minimum response time: $minTime ms"
Write-Host "Maximum response time: $maxTime ms"

# Save results to file
$date = Get-Date -Format "yyyyMMdd-HHmmss"
$results = @"
Benchmark Results ($date)
------------------------
API URL: $apiUrl
Total iterations: $iterations
Average response time: $avgTime ms
Minimum response time: $minTime ms
Maximum response time: $maxTime ms
"@

$results | Out-File -FilePath "benchmark-results-$date.txt"
Write-Host "Results saved to benchmark-results-$date.txt"
