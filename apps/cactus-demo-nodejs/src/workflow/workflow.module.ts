import { Module } from "@nestjs/common";
import { WorkflowModuleBase } from "./base/workflow.module.base";
import { WorkflowService } from "./workflow.service";
import { WorkflowController } from "./workflow.controller";

@Module({
  imports: [WorkflowModuleBase],
  controllers: [WorkflowController],
  providers: [WorkflowService],
  exports: [WorkflowService],
})
export class WorkflowModule {}
