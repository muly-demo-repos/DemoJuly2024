import { Module } from "@nestjs/common";
import { EventTypeModuleBase } from "./base/eventType.module.base";
import { EventTypeService } from "./eventType.service";
import { EventTypeController } from "./eventType.controller";

@Module({
  imports: [EventTypeModuleBase],
  controllers: [EventTypeController],
  providers: [EventTypeService],
  exports: [EventTypeService],
})
export class EventTypeModule {}
