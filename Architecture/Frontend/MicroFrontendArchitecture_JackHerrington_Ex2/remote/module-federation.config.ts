export const mfConfig = {
  name: "remote",
  filename: "remoteEntry.js",
  exposes: {
    "./Counter": "./src/Counter.tsx"
  },
  shared: ["solid-js"],
};
