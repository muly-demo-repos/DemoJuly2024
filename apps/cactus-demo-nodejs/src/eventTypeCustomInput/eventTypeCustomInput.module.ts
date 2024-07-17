import { Module } from "@nestjs/common";
import { EventTypeCustomInputModuleBase } from "./base/eventTypeCustomInput.module.base";
import { EventTypeCustomInputService } from "./eventTypeCustomInput.service";
import { EventTypeCustomInputController } from "./eventTypeCustomInput.controller";

@Module({
  imports: [EventTypeCustomInputModuleBase],
  controllers: [EventTypeCustomInputController],
  providers: [EventTypeCustomInputService],
  exports: [EventTypeCustomInputService],
})
export class EventTypeCustomInputModule {}
