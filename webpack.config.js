const path = require('path');

module.exports = {
  entry: {
    main: './Assets/main.js'
  },
  output: {
  filename: './bundle.js',
    path: path.resolve(__dirname, 'wwwroot'),
    publicPath: '/'
  },
  mode: "development",
  module: {
    rules: [
      {
        test: /\.css$/,
        use: [
          'style-loader',
          'css-loader'
        ]
      },
      {
        test: /\.scss$/,
        use: [
          {
            loader: 'style-loader'
          },
          {
            loader: 'css-loader'
          },
          {
            loader: 'postcss-loader',
            options: {
              plugins: function() {
                return [
                  require('precss'),
                  require('autoprefixer')
                ];
              }
            }
          },
          {
            loader: 'sass-loader'
          }
        ]
      }
    ]
  }
};