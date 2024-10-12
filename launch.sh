#!/bin/bash

dapr run --app-id "company-api" \
    --app-port "5052" \
    --dapr-grpc-port "38591" \
    --dapr-http-port "5010" \
    --resources-path "./dapr/components" \
    --config "./dapr/components/awc-config.yaml" \
    -- dotnet run --project ./src/Services/Company/Company.API/Company.API.csproj --urls="http://+:5052" &