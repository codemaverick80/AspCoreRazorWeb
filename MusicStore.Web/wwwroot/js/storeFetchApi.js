/**
 * storeFetchApi Library
 * Library for making HTTP requests using Fetch API
 *
 * @version 2.0.0
 * @author Harish Chand
 * @license MIT
 *
 */

class storeFetchApi {

    /**
     *
     * fetch() API only rejects a promise when a “network error is encountered, although this usually means permissions issues or similar.”
     * Basically fetch() will only reject a promise if the user is offline, or some unlikely networking error occurs, such a DNS lookup failure.

     * The good is news is fetch provides a simple ok flag that indicates whether an HTTP response’s status code is in the successful range or not
     *
     */

    /**
     * Response handler
     * @param response
     */

   handleResponse(response) {
        if (!response.ok)throw Error(response.statusText + ' - ' + response.status);
        return response.json();
    }


    /**
     * Make http GET request
     * @param {string} url - api endpoint url
     */
    get(url) {
        return new Promise((resolve, reject) => {
            fetch(url)
                .then(res => this.handleResponse(res))
                .then(data => resolve(data))
                .catch(err => reject(err));
        });
    }

    //get(url) {
    //    return new Promise((resolve, reject) => {
    //        fetch(url)
    //            .then(function (res) {
    //                if (!res.ok) {
    //                    throw Error(res.statusText + ' - ' + res.status);
    //                } 
    //                return res.json()                    
    //            })
    //            .then(function (data) {
    //                return resolve(data)
    //            })
    //            .catch(function (err) {
    //               return reject(err)
    //            });
    //    });
    //}

    /**
     * Make http POST request
     * @param {string} url - api endpoint url
     * @param {Object} - post request payload
     * */

    post(url, data) {
        return new Promise((resolve, reject) => {
            fetch(url, {
                method: 'POST',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify(data),
            })
                .then(res => res.json())
                .then(data => resolve(data))
                .catch(err => reject(err));
        });
    }

    /** Make http PUT request */

    put(url, data) {
        return new Promise((resolve, reject) => {
            fetch(url, {
                method: 'PUT',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify(data),
            })
                .then(res => res.json())
                .then(data => resolve(data))
                .catch(err => reject(err));
        });
    }

    /** Make http DELETE request */

    delete(url) {
        return new Promise((resolve, reject) => {
            fetch(url, {
                method: 'delete',
                headers: { 'Content-type': 'application/json' },
            })
                .then(res => res.json())
                .then(data => resolve('Resource Deleted'))
                .catch(err => reject(err));
        });
    }


}