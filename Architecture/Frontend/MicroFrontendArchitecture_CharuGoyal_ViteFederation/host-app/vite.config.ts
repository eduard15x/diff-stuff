import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import federation from "@originjs/vite-plugin-federation";

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    react(),
    federation({
      name: "host-app",
      remotes: {
        remote_app: "http://localhost:5001/assets/remoteEntry.js",
        remote_app_another_react: "http://localhost:5002/assets/remoteEntry.js",
        remote_app_another_vue: "http://localhost:5003/assets/remoteEntry.js",
      },
      shared: ["react", "react-dom", "vue"],
      // shared: {
      //   react: {
      //     // singleton: true,
      //     requiredVersion: "^18.0.0",
      //   },
      //   "react-dom": {
      //     // singleton: true,
      //     requiredVersion: "^18.0.0",
      //   },
      // },
    }),
  ],
  build: {
    modulePreload: false,
    target: "esnext",
    minify: false,
    cssCodeSplit: false,
  },
});
