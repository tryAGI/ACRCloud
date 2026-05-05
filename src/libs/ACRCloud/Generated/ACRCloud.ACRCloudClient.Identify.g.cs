
#nullable enable

namespace ACRCloud
{
    public partial class ACRCloudClient
    {
        partial void PrepareIdentifyArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::ACRCloud.IdentifyRequest request);
        partial void PrepareIdentifyRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::ACRCloud.IdentifyRequest request);
        partial void ProcessIdentifyResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessIdentifyResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// Identify audio or fingerprint<br/>
        /// Identifies an audio file or fingerprint file. ACRCloud requires HMAC-SHA1<br/>
        /// request signing over method, path, access key, data type, signature version,<br/>
        /// and timestamp.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::ACRCloud.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::ACRCloud.IdentifyResponse> IdentifyAsync(

            global::ACRCloud.IdentifyRequest request,
            global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __response = await IdentifyAsResponseAsync(

                request: request,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);

            return __response.Body;
        }
        /// <summary>
        /// Identify audio or fingerprint<br/>
        /// Identifies an audio file or fingerprint file. ACRCloud requires HMAC-SHA1<br/>
        /// request signing over method, path, access key, data type, signature version,<br/>
        /// and timestamp.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::ACRCloud.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::ACRCloud.AutoSDKHttpResponse<global::ACRCloud.IdentifyResponse>> IdentifyAsResponseAsync(

            global::ACRCloud.IdentifyRequest request,
            global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareIdentifyArguments(
                httpClient: HttpClient,
                request: request);

            using var __timeoutCancellationTokenSource = global::ACRCloud.AutoSDKRequestOptionsSupport.CreateTimeoutCancellationTokenSource(
                clientOptions: Options,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken);
            var __effectiveCancellationToken = __timeoutCancellationTokenSource?.Token ?? cancellationToken;
            var __effectiveReadResponseAsString = global::ACRCloud.AutoSDKRequestOptionsSupport.GetReadResponseAsString(
                clientOptions: Options,
                requestOptions: requestOptions,
                fallbackValue: ReadResponseAsString);
            var __maxAttempts = global::ACRCloud.AutoSDKRequestOptionsSupport.GetMaxAttempts(
                clientOptions: Options,
                requestOptions: requestOptions,
                supportsRetry: false);

            global::System.Net.Http.HttpRequestMessage __CreateHttpRequest()
            {

                            var __pathBuilder = new global::ACRCloud.PathBuilder(
                                path: "/v1/identify",
                                baseUri: HttpClient.BaseAddress);
                            var __path = __pathBuilder.ToString();
                __path = global::ACRCloud.AutoSDKRequestOptionsSupport.AppendQueryParameters(
                    path: __path,
                    clientParameters: Options.QueryParameters,
                    requestParameters: requestOptions?.QueryParameters);
                var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                    method: global::System.Net.Http.HttpMethod.Post,
                    requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
#if NET6_0_OR_GREATER
                __httpRequest.Version = global::System.Net.HttpVersion.Version11;
                __httpRequest.VersionPolicy = global::System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher;
#endif

                            var __httpRequestContent = new global::System.Net.Http.MultipartFormDataContent();
                            var __contentSample = new global::System.Net.Http.ByteArrayContent(request.Sample ?? global::System.Array.Empty<byte>());
                            __contentSample.Headers.ContentType = new global::System.Net.Http.Headers.MediaTypeHeaderValue(
                                request.Samplename is null
                                    ? "application/octet-stream"
                                    : (global::System.IO.Path.GetExtension(request.Samplename) ?? string.Empty).ToLowerInvariant() switch
                                    {
                                        ".aac" => "audio/aac",
                                        ".flac" => "audio/flac",
                                        ".gif" => "image/gif",
                                        ".jpeg" => "image/jpeg",
                                        ".jpg" => "image/jpeg",
                                        ".json" => "application/json",
                                        ".m4a" => "audio/mp4",
                                        ".mp3" => "audio/mpeg",
                                        ".mp4" => "video/mp4",
                                        ".mpeg" => "audio/mpeg",
                                        ".mpga" => "audio/mpeg",
                                        ".oga" => "audio/ogg",
                                        ".ogg" => "audio/ogg",
                                        ".opus" => "audio/ogg",
                                        ".pdf" => "application/pdf",
                                        ".png" => "image/png",
                                        ".txt" => "text/plain",
                                        ".wav" => "audio/wav",
                                        ".weba" => "audio/webm",
                                        ".webm" => "video/webm",
                                        ".webp" => "image/webp",
                                        _ => "application/octet-stream",
                                    });
                            __httpRequestContent.Add(
                                content: __contentSample,
                                name: "\"sample\"",
                                fileName: request.Samplename != null ? $"\"{request.Samplename}\"" : string.Empty);
                            if (__contentSample.Headers.ContentDisposition != null)
                            {
                                __contentSample.Headers.ContentDisposition.FileNameStar = null;
                            }

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.AccessKey ?? string.Empty),
                                name: "\"access_key\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(global::System.Convert.ToString(request.SampleBytes, global::System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty),
                                name: "\"sample_bytes\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.Timestamp ?? string.Empty),
                                name: "\"timestamp\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.Signature ?? string.Empty),
                                name: "\"signature\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.DataType ?? string.Empty),
                                name: "\"data_type\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.SignatureVersion ?? string.Empty),
                                name: "\"signature_version\"");

                            __httpRequest.Content = __httpRequestContent;

                global::ACRCloud.AutoSDKRequestOptionsSupport.ApplyHeaders(
                    request: __httpRequest,
                    clientHeaders: Options.Headers,
                    requestHeaders: requestOptions?.Headers);

                PrepareRequest(
                    client: HttpClient,
                    request: __httpRequest);
                PrepareIdentifyRequest(
                    httpClient: HttpClient,
                    httpRequestMessage: __httpRequest,
                    request: request);

                return __httpRequest;
            }

            global::System.Net.Http.HttpRequestMessage? __httpRequest = null;
            global::System.Net.Http.HttpResponseMessage? __response = null;
            var __attemptNumber = 0;
            try
            {
                for (var __attempt = 1; __attempt <= __maxAttempts; __attempt++)
                {
                    __attemptNumber = __attempt;
                    __httpRequest = __CreateHttpRequest();
                    await global::ACRCloud.AutoSDKRequestOptionsSupport.OnBeforeRequestAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                    try
                    {
                        __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                    }
                    catch (global::System.Net.Http.HttpRequestException __exception)
                    {
                        var __retryDelay = global::ACRCloud.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: null,
                            attempt: __attempt);
                        var __willRetry = __attempt < __maxAttempts && !__effectiveCancellationToken.IsCancellationRequested;
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: __exception,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: __willRetry,
                                retryDelay: __willRetry ? __retryDelay : (global::System.TimeSpan?)null,
                                retryReason: "exception",
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        if (!__willRetry)
                        {
                            throw;
                        }

                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    if (__response != null &&
                        __attempt < __maxAttempts &&
                        global::ACRCloud.AutoSDKRequestOptionsSupport.ShouldRetryStatusCode(__response.StatusCode))
                    {
                        var __retryDelay = global::ACRCloud.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: __response,
                            attempt: __attempt);
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: true,
                                retryDelay: __retryDelay,
                                retryReason: "status:" + ((int)__response.StatusCode).ToString(global::System.Globalization.CultureInfo.InvariantCulture),
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        __response.Dispose();
                        __response = null;
                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    break;
                }

                if (__response == null)
                {
                    throw new global::System.InvalidOperationException("No response received.");
                }

                using (__response)
                {

                ProcessResponse(
                    client: HttpClient,
                    response: __response);
                ProcessIdentifyResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }

                            if (__effectiveReadResponseAsString)
                            {
                                var __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                    __effectiveCancellationToken
                #endif
                                ).ConfigureAwait(false);

                                ProcessResponseContent(
                                    client: HttpClient,
                                    response: __response,
                                    content: ref __content);
                                ProcessIdentifyResponseContent(
                                    httpClient: HttpClient,
                                    httpResponseMessage: __response,
                                    content: ref __content);

                                try
                                {
                                    __response.EnsureSuccessStatusCode();

                                    var __value = global::ACRCloud.IdentifyResponse.FromJson(__content, JsonSerializerContext) ??
                                        throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");
                                    return new global::ACRCloud.AutoSDKHttpResponse<global::ACRCloud.IdentifyResponse>(
                                        statusCode: __response.StatusCode,
                                        headers: global::ACRCloud.AutoSDKHttpResponse.CreateHeaders(__response),
                                        requestUri: __response.RequestMessage?.RequestUri,
                                        body: __value);
                                }
                                catch (global::System.Exception __ex)
                                {
                                    throw new global::ACRCloud.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
                                }
                            }
                            else
                            {
                                try
                                {
                                    __response.EnsureSuccessStatusCode();
                                    using var __content = await __response.Content.ReadAsStreamAsync(
                #if NET5_0_OR_GREATER
                                        __effectiveCancellationToken
                #endif
                                    ).ConfigureAwait(false);

                                    var __value = await global::ACRCloud.IdentifyResponse.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
                                        throw new global::System.InvalidOperationException("Response deserialization failed.");
                                    return new global::ACRCloud.AutoSDKHttpResponse<global::ACRCloud.IdentifyResponse>(
                                        statusCode: __response.StatusCode,
                                        headers: global::ACRCloud.AutoSDKHttpResponse.CreateHeaders(__response),
                                        requestUri: __response.RequestMessage?.RequestUri,
                                        body: __value);
                                }
                                catch (global::System.Exception __ex)
                                {
                                    string? __content = null;
                                    try
                                    {
                                        __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                            __effectiveCancellationToken
                #endif
                                        ).ConfigureAwait(false);
                                    }
                                    catch (global::System.Exception)
                                    {
                                    }

                                    throw new global::ACRCloud.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
                                }
                            }

                }
            }
            finally
            {
                __httpRequest?.Dispose();
            }
        }
        /// <summary>
        /// Identify audio or fingerprint<br/>
        /// Identifies an audio file or fingerprint file. ACRCloud requires HMAC-SHA1<br/>
        /// request signing over method, path, access key, data type, signature version,<br/>
        /// and timestamp.
        /// </summary>
        /// <param name="sample">
        /// Audio file or fingerprint file.
        /// </param>
        /// <param name="samplename">
        /// Audio file or fingerprint file.
        /// </param>
        /// <param name="accessKey">
        /// Project access key.
        /// </param>
        /// <param name="sampleBytes">
        /// File size in bytes. ACRCloud recommends short clips and documents a maximum below 5 MB.
        /// </param>
        /// <param name="timestamp">
        /// Unix timestamp used in the request signature.
        /// </param>
        /// <param name="signature">
        /// Base64-encoded HMAC-SHA1 signature.
        /// </param>
        /// <param name="dataType">
        /// audio or fingerprint.
        /// </param>
        /// <param name="signatureVersion">
        /// Signature protocol version. Use 1.
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::ACRCloud.IdentifyResponse> IdentifyAsync(
            byte[] sample,
            string samplename,
            string accessKey,
            long sampleBytes,
            string timestamp,
            string signature,
            string dataType,
            string signatureVersion,
            global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::ACRCloud.IdentifyRequest
            {
                Sample = sample,
                Samplename = samplename,
                AccessKey = accessKey,
                SampleBytes = sampleBytes,
                Timestamp = timestamp,
                Signature = signature,
                DataType = dataType,
                SignatureVersion = signatureVersion,
            };

            return await IdentifyAsync(
                request: __request,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Identify audio or fingerprint<br/>
        /// Identifies an audio file or fingerprint file. ACRCloud requires HMAC-SHA1<br/>
        /// request signing over method, path, access key, data type, signature version,<br/>
        /// and timestamp.
        /// </summary>
        /// <param name="sample">
        /// Audio file or fingerprint file.
        /// </param>
        /// <param name="samplename">
        /// Audio file or fingerprint file.
        /// </param>
        /// <param name="accessKey">
        /// Project access key.
        /// </param>
        /// <param name="sampleBytes">
        /// File size in bytes. ACRCloud recommends short clips and documents a maximum below 5 MB.
        /// </param>
        /// <param name="timestamp">
        /// Unix timestamp used in the request signature.
        /// </param>
        /// <param name="signature">
        /// Base64-encoded HMAC-SHA1 signature.
        /// </param>
        /// <param name="dataType">
        /// audio or fingerprint.
        /// </param>
        /// <param name="signatureVersion">
        /// Signature protocol version. Use 1.
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::ACRCloud.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::ACRCloud.IdentifyResponse> IdentifyAsync(
            global::System.IO.Stream sample,
            string samplename,
            string accessKey,
            long sampleBytes,
            string timestamp,
            string signature,
            string dataType,
            string signatureVersion,
            global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            sample = sample ?? throw new global::System.ArgumentNullException(nameof(sample));
            var request = new global::ACRCloud.IdentifyRequest
            {
                Sample = global::System.Array.Empty<byte>(),
                Samplename = samplename,
                AccessKey = accessKey,
                SampleBytes = sampleBytes,
                Timestamp = timestamp,
                Signature = signature,
                DataType = dataType,
                SignatureVersion = signatureVersion,
            };
            PrepareArguments(
                client: HttpClient);
            PrepareIdentifyArguments(
                httpClient: HttpClient,
                request: request);

            using var __timeoutCancellationTokenSource = global::ACRCloud.AutoSDKRequestOptionsSupport.CreateTimeoutCancellationTokenSource(
                clientOptions: Options,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken);
            var __effectiveCancellationToken = __timeoutCancellationTokenSource?.Token ?? cancellationToken;
            var __effectiveReadResponseAsString = global::ACRCloud.AutoSDKRequestOptionsSupport.GetReadResponseAsString(
                clientOptions: Options,
                requestOptions: requestOptions,
                fallbackValue: ReadResponseAsString);
            var __maxAttempts = global::ACRCloud.AutoSDKRequestOptionsSupport.GetMaxAttempts(
                clientOptions: Options,
                requestOptions: requestOptions,
                supportsRetry: false);

            global::System.Net.Http.HttpRequestMessage __CreateHttpRequest()
            {

                            var __pathBuilder = new global::ACRCloud.PathBuilder(
                                path: "/v1/identify",
                                baseUri: HttpClient.BaseAddress);
                            var __path = __pathBuilder.ToString();
                __path = global::ACRCloud.AutoSDKRequestOptionsSupport.AppendQueryParameters(
                    path: __path,
                    clientParameters: Options.QueryParameters,
                    requestParameters: requestOptions?.QueryParameters);
                var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                    method: global::System.Net.Http.HttpMethod.Post,
                    requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
#if NET6_0_OR_GREATER
                __httpRequest.Version = global::System.Net.HttpVersion.Version11;
                __httpRequest.VersionPolicy = global::System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher;
#endif

                            var __httpRequestContent = new global::System.Net.Http.MultipartFormDataContent();
                            var __contentSample = new global::System.Net.Http.StreamContent(sample);
                            __contentSample.Headers.ContentType = new global::System.Net.Http.Headers.MediaTypeHeaderValue(
                                request.Samplename is null
                                    ? "application/octet-stream"
                                    : (global::System.IO.Path.GetExtension(request.Samplename) ?? string.Empty).ToLowerInvariant() switch
                                    {
                                        ".aac" => "audio/aac",
                                        ".flac" => "audio/flac",
                                        ".gif" => "image/gif",
                                        ".jpeg" => "image/jpeg",
                                        ".jpg" => "image/jpeg",
                                        ".json" => "application/json",
                                        ".m4a" => "audio/mp4",
                                        ".mp3" => "audio/mpeg",
                                        ".mp4" => "video/mp4",
                                        ".mpeg" => "audio/mpeg",
                                        ".mpga" => "audio/mpeg",
                                        ".oga" => "audio/ogg",
                                        ".ogg" => "audio/ogg",
                                        ".opus" => "audio/ogg",
                                        ".pdf" => "application/pdf",
                                        ".png" => "image/png",
                                        ".txt" => "text/plain",
                                        ".wav" => "audio/wav",
                                        ".weba" => "audio/webm",
                                        ".webm" => "video/webm",
                                        ".webp" => "image/webp",
                                        _ => "application/octet-stream",
                                    });
                            __httpRequestContent.Add(
                                content: __contentSample,
                                name: "\"sample\"",
                                fileName: request.Samplename != null ? $"\"{request.Samplename}\"" : string.Empty);
                            if (__contentSample.Headers.ContentDisposition != null)
                            {
                                __contentSample.Headers.ContentDisposition.FileNameStar = null;
                            }

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.AccessKey ?? string.Empty),
                                name: "\"access_key\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(global::System.Convert.ToString(request.SampleBytes, global::System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty),
                                name: "\"sample_bytes\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.Timestamp ?? string.Empty),
                                name: "\"timestamp\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.Signature ?? string.Empty),
                                name: "\"signature\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.DataType ?? string.Empty),
                                name: "\"data_type\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.SignatureVersion ?? string.Empty),
                                name: "\"signature_version\"");

                            __httpRequest.Content = __httpRequestContent;

                global::ACRCloud.AutoSDKRequestOptionsSupport.ApplyHeaders(
                    request: __httpRequest,
                    clientHeaders: Options.Headers,
                    requestHeaders: requestOptions?.Headers);

                PrepareRequest(
                    client: HttpClient,
                    request: __httpRequest);
                PrepareIdentifyRequest(
                    httpClient: HttpClient,
                    httpRequestMessage: __httpRequest,
                    request: request);

                return __httpRequest;
            }

            global::System.Net.Http.HttpRequestMessage? __httpRequest = null;
            global::System.Net.Http.HttpResponseMessage? __response = null;
            var __attemptNumber = 0;
            try
            {
                for (var __attempt = 1; __attempt <= __maxAttempts; __attempt++)
                {
                    __attemptNumber = __attempt;
                    __httpRequest = __CreateHttpRequest();
                    await global::ACRCloud.AutoSDKRequestOptionsSupport.OnBeforeRequestAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                    try
                    {
                        __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                    }
                    catch (global::System.Net.Http.HttpRequestException __exception)
                    {
                        var __retryDelay = global::ACRCloud.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: null,
                            attempt: __attempt);
                        var __willRetry = __attempt < __maxAttempts && !__effectiveCancellationToken.IsCancellationRequested;
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: __exception,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: __willRetry,
                                retryDelay: __willRetry ? __retryDelay : (global::System.TimeSpan?)null,
                                retryReason: "exception",
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        if (!__willRetry)
                        {
                            throw;
                        }

                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    if (__response != null &&
                        __attempt < __maxAttempts &&
                        global::ACRCloud.AutoSDKRequestOptionsSupport.ShouldRetryStatusCode(__response.StatusCode))
                    {
                        var __retryDelay = global::ACRCloud.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: __response,
                            attempt: __attempt);
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: true,
                                retryDelay: __retryDelay,
                                retryReason: "status:" + ((int)__response.StatusCode).ToString(global::System.Globalization.CultureInfo.InvariantCulture),
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        __response.Dispose();
                        __response = null;
                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    break;
                }

                if (__response == null)
                {
                    throw new global::System.InvalidOperationException("No response received.");
                }

                using (__response)
                {

                ProcessResponse(
                    client: HttpClient,
                    response: __response);
                ProcessIdentifyResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }

                            if (__effectiveReadResponseAsString)
                            {
                                var __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                    __effectiveCancellationToken
                #endif
                                ).ConfigureAwait(false);

                                ProcessResponseContent(
                                    client: HttpClient,
                                    response: __response,
                                    content: ref __content);
                                ProcessIdentifyResponseContent(
                                    httpClient: HttpClient,
                                    httpResponseMessage: __response,
                                    content: ref __content);

                                try
                                {
                                    __response.EnsureSuccessStatusCode();

                                    return
                                        global::ACRCloud.IdentifyResponse.FromJson(__content, JsonSerializerContext) ??
                                        throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");
                                }
                                catch (global::System.Exception __ex)
                                {
                                    throw new global::ACRCloud.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
                                }
                            }
                            else
                            {
                                try
                                {
                                    __response.EnsureSuccessStatusCode();
                                    using var __content = await __response.Content.ReadAsStreamAsync(
                #if NET5_0_OR_GREATER
                                        __effectiveCancellationToken
                #endif
                                    ).ConfigureAwait(false);

                                    return
                                        await global::ACRCloud.IdentifyResponse.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
                                        throw new global::System.InvalidOperationException("Response deserialization failed.");
                                }
                                catch (global::System.Exception __ex)
                                {
                                    string? __content = null;
                                    try
                                    {
                                        __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                            __effectiveCancellationToken
                #endif
                                        ).ConfigureAwait(false);
                                    }
                                    catch (global::System.Exception)
                                    {
                                    }

                                    throw new global::ACRCloud.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
                                }
                            }

                }
            }
            finally
            {
                __httpRequest?.Dispose();
            }
        }
        /// <summary>
        /// Identify audio or fingerprint<br/>
        /// Identifies an audio file or fingerprint file. ACRCloud requires HMAC-SHA1<br/>
        /// request signing over method, path, access key, data type, signature version,<br/>
        /// and timestamp.
        /// </summary>
        /// <param name="sample">
        /// Audio file or fingerprint file.
        /// </param>
        /// <param name="samplename">
        /// Audio file or fingerprint file.
        /// </param>
        /// <param name="accessKey">
        /// Project access key.
        /// </param>
        /// <param name="sampleBytes">
        /// File size in bytes. ACRCloud recommends short clips and documents a maximum below 5 MB.
        /// </param>
        /// <param name="timestamp">
        /// Unix timestamp used in the request signature.
        /// </param>
        /// <param name="signature">
        /// Base64-encoded HMAC-SHA1 signature.
        /// </param>
        /// <param name="dataType">
        /// audio or fingerprint.
        /// </param>
        /// <param name="signatureVersion">
        /// Signature protocol version. Use 1.
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::ACRCloud.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::ACRCloud.AutoSDKHttpResponse<global::ACRCloud.IdentifyResponse>> IdentifyAsResponseAsync(
            global::System.IO.Stream sample,
            string samplename,
            string accessKey,
            long sampleBytes,
            string timestamp,
            string signature,
            string dataType,
            string signatureVersion,
            global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            sample = sample ?? throw new global::System.ArgumentNullException(nameof(sample));
            var request = new global::ACRCloud.IdentifyRequest
            {
                Sample = global::System.Array.Empty<byte>(),
                Samplename = samplename,
                AccessKey = accessKey,
                SampleBytes = sampleBytes,
                Timestamp = timestamp,
                Signature = signature,
                DataType = dataType,
                SignatureVersion = signatureVersion,
            };
            PrepareArguments(
                client: HttpClient);
            PrepareIdentifyArguments(
                httpClient: HttpClient,
                request: request);

            using var __timeoutCancellationTokenSource = global::ACRCloud.AutoSDKRequestOptionsSupport.CreateTimeoutCancellationTokenSource(
                clientOptions: Options,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken);
            var __effectiveCancellationToken = __timeoutCancellationTokenSource?.Token ?? cancellationToken;
            var __effectiveReadResponseAsString = global::ACRCloud.AutoSDKRequestOptionsSupport.GetReadResponseAsString(
                clientOptions: Options,
                requestOptions: requestOptions,
                fallbackValue: ReadResponseAsString);
            var __maxAttempts = global::ACRCloud.AutoSDKRequestOptionsSupport.GetMaxAttempts(
                clientOptions: Options,
                requestOptions: requestOptions,
                supportsRetry: false);

            global::System.Net.Http.HttpRequestMessage __CreateHttpRequest()
            {

                            var __pathBuilder = new global::ACRCloud.PathBuilder(
                                path: "/v1/identify",
                                baseUri: HttpClient.BaseAddress);
                            var __path = __pathBuilder.ToString();
                __path = global::ACRCloud.AutoSDKRequestOptionsSupport.AppendQueryParameters(
                    path: __path,
                    clientParameters: Options.QueryParameters,
                    requestParameters: requestOptions?.QueryParameters);
                var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                    method: global::System.Net.Http.HttpMethod.Post,
                    requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
#if NET6_0_OR_GREATER
                __httpRequest.Version = global::System.Net.HttpVersion.Version11;
                __httpRequest.VersionPolicy = global::System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher;
#endif

                            var __httpRequestContent = new global::System.Net.Http.MultipartFormDataContent();
                            var __contentSample = new global::System.Net.Http.StreamContent(sample);
                            __contentSample.Headers.ContentType = new global::System.Net.Http.Headers.MediaTypeHeaderValue(
                                request.Samplename is null
                                    ? "application/octet-stream"
                                    : (global::System.IO.Path.GetExtension(request.Samplename) ?? string.Empty).ToLowerInvariant() switch
                                    {
                                        ".aac" => "audio/aac",
                                        ".flac" => "audio/flac",
                                        ".gif" => "image/gif",
                                        ".jpeg" => "image/jpeg",
                                        ".jpg" => "image/jpeg",
                                        ".json" => "application/json",
                                        ".m4a" => "audio/mp4",
                                        ".mp3" => "audio/mpeg",
                                        ".mp4" => "video/mp4",
                                        ".mpeg" => "audio/mpeg",
                                        ".mpga" => "audio/mpeg",
                                        ".oga" => "audio/ogg",
                                        ".ogg" => "audio/ogg",
                                        ".opus" => "audio/ogg",
                                        ".pdf" => "application/pdf",
                                        ".png" => "image/png",
                                        ".txt" => "text/plain",
                                        ".wav" => "audio/wav",
                                        ".weba" => "audio/webm",
                                        ".webm" => "video/webm",
                                        ".webp" => "image/webp",
                                        _ => "application/octet-stream",
                                    });
                            __httpRequestContent.Add(
                                content: __contentSample,
                                name: "\"sample\"",
                                fileName: request.Samplename != null ? $"\"{request.Samplename}\"" : string.Empty);
                            if (__contentSample.Headers.ContentDisposition != null)
                            {
                                __contentSample.Headers.ContentDisposition.FileNameStar = null;
                            }

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.AccessKey ?? string.Empty),
                                name: "\"access_key\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(global::System.Convert.ToString(request.SampleBytes, global::System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty),
                                name: "\"sample_bytes\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.Timestamp ?? string.Empty),
                                name: "\"timestamp\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.Signature ?? string.Empty),
                                name: "\"signature\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.DataType ?? string.Empty),
                                name: "\"data_type\"");

                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent(request.SignatureVersion ?? string.Empty),
                                name: "\"signature_version\"");

                            __httpRequest.Content = __httpRequestContent;

                global::ACRCloud.AutoSDKRequestOptionsSupport.ApplyHeaders(
                    request: __httpRequest,
                    clientHeaders: Options.Headers,
                    requestHeaders: requestOptions?.Headers);

                PrepareRequest(
                    client: HttpClient,
                    request: __httpRequest);
                PrepareIdentifyRequest(
                    httpClient: HttpClient,
                    httpRequestMessage: __httpRequest,
                    request: request);

                return __httpRequest;
            }

            global::System.Net.Http.HttpRequestMessage? __httpRequest = null;
            global::System.Net.Http.HttpResponseMessage? __response = null;
            var __attemptNumber = 0;
            try
            {
                for (var __attempt = 1; __attempt <= __maxAttempts; __attempt++)
                {
                    __attemptNumber = __attempt;
                    __httpRequest = __CreateHttpRequest();
                    await global::ACRCloud.AutoSDKRequestOptionsSupport.OnBeforeRequestAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                    try
                    {
                        __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                    }
                    catch (global::System.Net.Http.HttpRequestException __exception)
                    {
                        var __retryDelay = global::ACRCloud.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: null,
                            attempt: __attempt);
                        var __willRetry = __attempt < __maxAttempts && !__effectiveCancellationToken.IsCancellationRequested;
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: __exception,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: __willRetry,
                                retryDelay: __willRetry ? __retryDelay : (global::System.TimeSpan?)null,
                                retryReason: "exception",
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        if (!__willRetry)
                        {
                            throw;
                        }

                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    if (__response != null &&
                        __attempt < __maxAttempts &&
                        global::ACRCloud.AutoSDKRequestOptionsSupport.ShouldRetryStatusCode(__response.StatusCode))
                    {
                        var __retryDelay = global::ACRCloud.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: __response,
                            attempt: __attempt);
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: true,
                                retryDelay: __retryDelay,
                                retryReason: "status:" + ((int)__response.StatusCode).ToString(global::System.Globalization.CultureInfo.InvariantCulture),
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        __response.Dispose();
                        __response = null;
                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::ACRCloud.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    break;
                }

                if (__response == null)
                {
                    throw new global::System.InvalidOperationException("No response received.");
                }

                using (__response)
                {

                ProcessResponse(
                    client: HttpClient,
                    response: __response);
                ProcessIdentifyResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    await global::ACRCloud.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::ACRCloud.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "Identify",
                                methodName: "IdentifyAsync",
                                pathTemplate: "\"/v1/identify\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }

                            if (__effectiveReadResponseAsString)
                            {
                                var __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                    __effectiveCancellationToken
                #endif
                                ).ConfigureAwait(false);

                                ProcessResponseContent(
                                    client: HttpClient,
                                    response: __response,
                                    content: ref __content);
                                ProcessIdentifyResponseContent(
                                    httpClient: HttpClient,
                                    httpResponseMessage: __response,
                                    content: ref __content);

                                try
                                {
                                    __response.EnsureSuccessStatusCode();

                                    var __value = global::ACRCloud.IdentifyResponse.FromJson(__content, JsonSerializerContext) ??
                                        throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");
                                    return new global::ACRCloud.AutoSDKHttpResponse<global::ACRCloud.IdentifyResponse>(
                                        statusCode: __response.StatusCode,
                                        headers: global::ACRCloud.AutoSDKHttpResponse.CreateHeaders(__response),
                                        requestUri: __response.RequestMessage?.RequestUri,
                                        body: __value);
                                }
                                catch (global::System.Exception __ex)
                                {
                                    throw new global::ACRCloud.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
                                }
                            }
                            else
                            {
                                try
                                {
                                    __response.EnsureSuccessStatusCode();
                                    using var __content = await __response.Content.ReadAsStreamAsync(
                #if NET5_0_OR_GREATER
                                        __effectiveCancellationToken
                #endif
                                    ).ConfigureAwait(false);

                                    var __value = await global::ACRCloud.IdentifyResponse.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
                                        throw new global::System.InvalidOperationException("Response deserialization failed.");
                                    return new global::ACRCloud.AutoSDKHttpResponse<global::ACRCloud.IdentifyResponse>(
                                        statusCode: __response.StatusCode,
                                        headers: global::ACRCloud.AutoSDKHttpResponse.CreateHeaders(__response),
                                        requestUri: __response.RequestMessage?.RequestUri,
                                        body: __value);
                                }
                                catch (global::System.Exception __ex)
                                {
                                    string? __content = null;
                                    try
                                    {
                                        __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                            __effectiveCancellationToken
                #endif
                                        ).ConfigureAwait(false);
                                    }
                                    catch (global::System.Exception)
                                    {
                                    }

                                    throw new global::ACRCloud.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
                                }
                            }

                }
            }
            finally
            {
                __httpRequest?.Dispose();
            }
        }
    }
}