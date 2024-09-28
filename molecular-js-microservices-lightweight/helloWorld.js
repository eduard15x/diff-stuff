import { ServiceBroker } from "moleculer"; // like a controller

const broker = new ServiceBroker();

// Greater service
broker.createService({
  name: "Greater",
  actions: {
    sayHello(context) {
      return `Hello ${context.params.name}`;
    },
  },
});

async function startApp() {
  await broker.start();
  const res = await broker.call("Greater.sayHello", { name: "Hello World" });
  console.log(res);
  broker.stop();
}

startApp();
