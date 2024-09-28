import { ServiceBroker } from "moleculer"; // like a controller
const broker = new ServiceBroker();

// we simulate DB
const users = [];

const generateRandomId = () => {
  return Math.floor(Math.random() * 1000) + 1;
};

broker.createService({
  name: "user",
  actions: {
    async createUser(ctx) {
      const { username, email } = ctx.params;
      const newUser = {
        id: generateRandomId(),
        username,
        email,
      };

      users.push(newUser);
      console.log("New User created", newUser);
      return newUser;
    },

    async getUsers(ctx) {
      return users;
    },
  },
});

export default broker;
