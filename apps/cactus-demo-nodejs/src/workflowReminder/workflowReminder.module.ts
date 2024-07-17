import { Module } from "@nestjs/common";
import { WorkflowReminderModuleBase } from "./base/workflowReminder.module.base";
import { WorkflowReminderService } from "./workflowReminder.service";
import { WorkflowReminderController } from "./workflowReminder.controller";

@Module({
  imports: [WorkflowReminderModuleBase],
  controllers: [WorkflowReminderController],
  providers: [WorkflowReminderService],
  exports: [WorkflowReminderService],
})
export class WorkflowReminderModule {}
