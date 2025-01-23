const AjaxHelper = (() => {
    
    const request = ({ url, method = 'GET', data = null, headers = {}, dataType = 'json' }) => {
        
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                type: method,
                data: data,
                headers: headers,
                dataType: dataType,
                success: (response) => resolve(response),
                error: (xhr, status, error) => reject({ xhr, status, error }),
            });
        });
    };

    const get = (url, headers = {}) => {
        return request({ url, method: 'GET', headers });
    };

    const post = (url, data, headers = {}) => {
        return request({ url, method: 'POST', data, headers });
    };

    const put = (url, data, headers = {}) => {
        return request({ url, method: 'PUT', data, headers });
    };

    const del = (url, headers = {}) => {
        return request({ url, method: 'DELETE', headers });
    };

    return {
        request,
        get,
        post,
        put,
        del,
    };
})();
