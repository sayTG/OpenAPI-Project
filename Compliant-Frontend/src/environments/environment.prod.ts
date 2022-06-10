export const environment = {
  production: true,
//Production

BASE_URL: 'https://localhost:7015',
  REQUESTS: [
    {
      verb: 'get',
      url: '/chuck/categories',
    },
    {
      verb: 'get',
      url:  '/search',
      queries: 'query=search',
    },
    {
      verb: 'get',
      url: '/swapi/people',
      queries: 'pages=1',
    },
  ],
  
};
