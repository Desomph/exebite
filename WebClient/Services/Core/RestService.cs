﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exebite.Common;
using WebClient.Extensions;
using WebClient.Wrappers;

namespace WebClient.Services.Core
{
    public abstract class RestService<TCreate, TQuery, TUpdate, TResult> : IRestService<TCreate, TQuery, TUpdate, TResult>
    {
        private readonly string _resourceUri;

        protected readonly IHttpClientWrapper _client;

        public RestService(string resourceUri, IHttpClientWrapper client)
        {
            _resourceUri = resourceUri;
            _client = client;
        }

        public async Task<int> CreateAsync(TCreate model, string authToken)
        {
            SetAuthToken(authToken);
            var response = await _client.PostAsJsonAsync(_resourceUri, model).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsAsync<dynamic>().ConfigureAwait(false);
            return body.id;
        }

        public async Task DeleteByIdAsync(int id, string authToken)
        {
            SetAuthToken(authToken);
            var response = await _client.DeleteAsync(_resourceUri + "/" + id).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        public async Task<PagingResult<TResult>> QueryAsync(TQuery query, string authToken)
        {
            SetAuthToken(authToken);
            var url = _resourceUri + "/Query?" + query.BuildQuery();

            var response = await _client.GetAsync(url).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<PagingResult<TResult>>().ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(int id, TUpdate model, string authToken)
        {
            SetAuthToken(authToken);
            var response = await _client.PutAsJsonAsync(_resourceUri + "/" + id, model);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsAsync<dynamic>().ConfigureAwait(false);
            return body.updated;
        }

        private void SetAuthToken(string authToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        }
    }
}