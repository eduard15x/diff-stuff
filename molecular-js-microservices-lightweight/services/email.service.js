import { ServiceBroker } from "moleculer"; // like a controller
const broker = new ServiceBroker();

// we simulate DB

broker.createService({
  name: "email",
  actions: {
    async sendEmail(ctx) {
      const { recipient, subject, content } = ctx.params;
      // Simulate email logic
      console.log(`Sending email to, ${recipient}, with subject ${subject}`);
      console.log(`Content: `, { content });

      return `Email sent to ${recipient}`;
    },
  },
});

export default broker;
