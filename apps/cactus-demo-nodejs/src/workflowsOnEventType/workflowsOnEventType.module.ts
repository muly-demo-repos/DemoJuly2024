import { Module } from "@nestjs/common";
import { WorkflowsOnEventTypeModuleBase } from "./base/workflowsOnEventType.module.base";
import { WorkflowsOnEventTypeService } from "./workflowsOnEventType.service";
import { WorkflowsOnEventTypeController } from "./workflowsOnEventType.controller";

@Module({
  imports: [WorkflowsOnEventTypeModuleBase],
  controllers: [WorkflowsOnEventTypeController],
  providers: [WorkflowsOnEventTypeService],
  exports: [WorkflowsOnEventTypeService],
})
export class WorkflowsOnEventTypeModule {}
