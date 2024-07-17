import { Module } from "@nestjs/common";
import { SelectedCalendarModuleBase } from "./base/selectedCalendar.module.base";
import { SelectedCalendarService } from "./selectedCalendar.service";
import { SelectedCalendarController } from "./selectedCalendar.controller";

@Module({
  imports: [SelectedCalendarModuleBase],
  controllers: [SelectedCalendarController],
  providers: [SelectedCalendarService],
  exports: [SelectedCalendarService],
})
export class SelectedCalendarModule {}
