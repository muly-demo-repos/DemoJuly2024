import { Module } from "@nestjs/common";
import { AttendeeModuleBase } from "./base/attendee.module.base";
import { AttendeeService } from "./attendee.service";
import { AttendeeController } from "./attendee.controller";

@Module({
  imports: [AttendeeModuleBase],
  controllers: [AttendeeController],
  providers: [AttendeeService],
  exports: [AttendeeService],
})
export class AttendeeModule {}
