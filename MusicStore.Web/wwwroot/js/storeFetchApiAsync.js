/**
 * storeFetchApiAsync Library
 * Library for making HTTP requests using Fetch API
 *
 * @version 3.0.0
 * @author Harish Chand
 * @license MIT
 *
 */

class storeFetchAsync {



    //async get(url) {

    //    // await response of fetch call
    //    let response = await fetch(url);
        
    //    if (!response.ok) throw Error(response.statusText + ' - ' + response.status);
        
    //    // only proceed once promise is resolved
    //    let data = await response.json();

    //    // only proceed once second promise is resolved
    //    return data;
    //}


    /**
     * Make http GET request
     * @param {string} url - api endpoint url
     */
    async get(url) {

        // await response of fetch call

        let response = await fetch(url);       

        let data= this.handleResponse(response);       
     
        return data;
    }


    /**
     * Response handler
     * @param response
     */
   async handleResponse(response) {
        if (!response.ok) throw Error(response.statusText + ' - ' + response.status);
        return await response.json();
    }


}