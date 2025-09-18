<template>
  <button @click="onClick">
    {{ text }}
  </button>
</template>

<script setup>
defineProps({
  text: {
    type: String,
    required: true,
  },
  onClick: {
    type: Function,
    required: true,
  },
});
</script>
