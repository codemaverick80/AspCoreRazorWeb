/**
 * storeXMLHttpRequest Library
 * Library for making HTTP requests
 *
 * @version 1.0.0
 * @author Harish Chand
 * @license MIT
 *
 */


function storeXMLHttpRequest() {
    this.http = new XMLHttpRequest();
}

/** Get Request */

storeXMLHttpRequest.prototype.get = function (url, callback) {
    this.http.open('GET', url, true);
    let self = this;

    this.http.onload = function () {
        if (self.http.status === 200) {
            callback(null, self.http.responseText);
        } else {
            callback('Error ' + self.http.status +' - '+self.http.statusText +'. at '+self.http.responseURL);
        }
    };
    this.http.send();

};

/** Post Request */
storeXMLHttpRequest.prototype.post = function (url, data, callback) {
    this.http.open('POST', url, true);
    this.http.setRequestHeader('Content-type', 'application/json;charset=UTF-8');

    let self = this;

    this.http.onload = function () {
        callback(null, self.http.responseText);
    };

    // send data as json
    this.http.send(JSON.stringify(data));
};

