#!/usr/bin/env bash
set -euo pipefail

# OpenAPI spec: locally maintained from
# https://docs.acrcloud.com/reference/identification-api/identification-api.

dotnet tool install --global autosdk.cli --prerelease

rm -rf Generated

# ACRCloud signs multipart form fields with HMAC-SHA1. OpenAPI cannot express
# that request-signing algorithm, so the generated raw method stays explicit
# and handwritten helpers add the convenient signed overloads.
autosdk generate openapi.yaml \
  --namespace ACRCloud \
  --clientClassName ACRCloudClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations
