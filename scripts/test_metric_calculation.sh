#!/bin/bash
dotnet test --filter "FullyQualifiedName~MetricCalculationTests" -l "console;verbosity=detailed"