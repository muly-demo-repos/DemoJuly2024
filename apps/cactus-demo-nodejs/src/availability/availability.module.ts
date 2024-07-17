import { Module } from "@nestjs/common";
import { AvailabilityModuleBase } from "./base/availability.module.base";
import { AvailabilityService } from "./availability.service";
import { AvailabilityController } from "./availability.controller";

@Module({
  imports: [AvailabilityModuleBase],
  controllers: [AvailabilityController],
  providers: [AvailabilityService],
  exports: [AvailabilityService],
})
export class AvailabilityModule {}
