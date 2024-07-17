import { Module } from "@nestjs/common";
import { ScheduleModuleBase } from "./base/schedule.module.base";
import { ScheduleService } from "./schedule.service";
import { ScheduleController } from "./schedule.controller";

@Module({
  imports: [ScheduleModuleBase],
  controllers: [ScheduleController],
  providers: [ScheduleService],
  exports: [ScheduleService],
})
export class ScheduleModule {}
