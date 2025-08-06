module.exports = {
  context: ['/api'], // Adjust context paths as needed
  target: 'https://localhost:44344', // Replace with your backend API URL
  secure: true, // Set to true if using HTTPS for the backend API
  changeOrigin: true, // Set to false if backend doesn't support CORS
  pathRewrite: { '^/api': '' } // Adjust path rewrite rules as needed
};
