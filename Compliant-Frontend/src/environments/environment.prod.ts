export const environment = {
  production: true,

  BASE_URL: 'https://jsonplaceholder.typicode.com',
  REQUESTS: [
    {
      verb: 'get',
      title: '/posts',
      url: 'https://jsonplaceholder.typicode.com/posts',
    },
    {
      verb: 'get',
      title: '/posts/1/comments',
      url: 'https://jsonplaceholder.typicode.com/posts/1/comments',
    },
    {
      verb: 'get',
      title: '/comments',
      url: 'https://jsonplaceholder.typicode.com/comments',
    },
    {
      verb: 'get',
      title: '/comments?postId=1',
      url: 'https://jsonplaceholder.typicode.com/comments?postId=1',
    },
  ],
};
