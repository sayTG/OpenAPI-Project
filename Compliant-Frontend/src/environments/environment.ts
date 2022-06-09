// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

var BASEURL = 'https://localhost:44396/';
var titles = ['chuck/categories', 'search']

export const environment = {
  production: false,

  BASE_URL : BASEURL,
  REQUESTS: [
    {
      verb: 'get',
      title: titles[0],
      url: BASEURL+titles[0],
    },
    {
      verb: 'get',
      title: titles[1],
      url:  BASEURL+titles[1],
      //'https://jsonplaceholder.typicode.com/posts/1/comments',
    },
    {
      verb: 'get',
      title: '/swapi/people',
      url: 'https://localhost:44396/chuck/categories',
    },
  ],
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
