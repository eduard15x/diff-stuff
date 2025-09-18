import { defineCustomElement } from "vue";
import Button from "./components/Button.vue";

export const ButtonElement = defineCustomElement(Button);
customElements.define("vue-remote-button", ButtonElement);
