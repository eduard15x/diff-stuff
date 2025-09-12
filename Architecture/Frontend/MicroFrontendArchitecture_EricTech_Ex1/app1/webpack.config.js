const HtmlWebpackPlugin = require("html-webpack-plugin");
const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");

module.exports = {
  mode: "development",
  devServer: {
    port: 8083,
  },
  module: {
    rules: [
      {
        // The following line to ask Babel to compile any file with extension .js
        test: /\.js$/,
        // Exluce node_modules directory from Babel.
        // Babel will not compile any file in this directory
        exclude: /node_modules/,
        // To use babel-loader for transpiling JavaScript files
        loader: "babel-loader",
        options: {
          presets: [
            "@babel/preset-env", // To transfer any advanced ES to ES5
            "@babel/preset-react", // To compile react to ES5
          ],
        },
      },
    ],
  },
  plugins: [
    new ModuleFederationPlugin({
      name: "app1",
      filename: "remoteEntry.js",
      exposes: {
        "./Button": "./src/Button",
      },
      //   remotes: {
      //     app1: "app1@http://localhost:8083/remoteEntry.js",
      //   }
    }),
    new HtmlWebpackPlugin({
      template: "./public/index.html",
    }),
  ],
};
