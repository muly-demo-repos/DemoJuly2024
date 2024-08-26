import { Module } from "@nestjs/common";
import { SensorTypeModuleBase } from "./base/sensorType.module.base";
import { SensorTypeService } from "./sensorType.service";
import { SensorTypeController } from "./sensorType.controller";
import { SensorTypeResolver } from "./sensorType.resolver";

@Module({
  imports: [SensorTypeModuleBase],
  controllers: [SensorTypeController],
  providers: [SensorTypeService, SensorTypeResolver],
  exports: [SensorTypeService],
})
export class SensorTypeModule {}
