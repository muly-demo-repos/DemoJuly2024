import { Module } from "@nestjs/common";
import { SensorReadingModuleBase } from "./base/sensorReading.module.base";
import { SensorReadingService } from "./sensorReading.service";
import { SensorReadingController } from "./sensorReading.controller";
import { SensorReadingResolver } from "./sensorReading.resolver";

@Module({
  imports: [SensorReadingModuleBase],
  controllers: [SensorReadingController],
  providers: [SensorReadingService, SensorReadingResolver],
  exports: [SensorReadingService],
})
export class SensorReadingModule {}
