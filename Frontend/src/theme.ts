import { createSystem, defaultConfig, defineConfig } from "@chakra-ui/react";

const customConfig = defineConfig({
  theme: {
    tokens: {
      colors: {
        primary: {
          value: "#026a96"
        }
      }
    }
  }
})

export const system = createSystem(defaultConfig, customConfig);
