import { Module } from "@nestjs/common";
import { DestinationCalendarModuleBase } from "./base/destinationCalendar.module.base";
import { DestinationCalendarService } from "./destinationCalendar.service";
import { DestinationCalendarController } from "./destinationCalendar.controller";

@Module({
  imports: [DestinationCalendarModuleBase],
  controllers: [DestinationCalendarController],
  providers: [DestinationCalendarService],
  exports: [DestinationCalendarService],
})
export class DestinationCalendarModule {}
