import { Module } from "@nestjs/common";
import { ReminderMailModuleBase } from "./base/reminderMail.module.base";
import { ReminderMailService } from "./reminderMail.service";
import { ReminderMailController } from "./reminderMail.controller";

@Module({
  imports: [ReminderMailModuleBase],
  controllers: [ReminderMailController],
  providers: [ReminderMailService],
  exports: [ReminderMailService],
})
export class ReminderMailModule {}
