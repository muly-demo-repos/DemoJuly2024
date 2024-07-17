import { Module } from "@nestjs/common";
import { WorkflowStepModuleBase } from "./base/workflowStep.module.base";
import { WorkflowStepService } from "./workflowStep.service";
import { WorkflowStepController } from "./workflowStep.controller";

@Module({
  imports: [WorkflowStepModuleBase],
  controllers: [WorkflowStepController],
  providers: [WorkflowStepService],
  exports: [WorkflowStepService],
})
export class WorkflowStepModule {}
