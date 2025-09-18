import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import federation from "@originjs/vite-plugin-federation";

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    vue(),
    federation({
      name: "remote-app-another-vue",
      filename: "remoteEntry.js",
      exposes: {
        "./Button": "./src/components/Button.vue", // doesnt work to lodd in react because is not JSX
        "./ButtonElement": "./src/register-web-components",
      },
      shared: ["vue"],
    }),
  ],
  build: {
    modulePreload: false,
    target: "esnext",
    minify: false,
    cssCodeSplit: false,
  },
  preview: {
    port: 5003,
    strictPort: true,
    cors: true,
  },
});
