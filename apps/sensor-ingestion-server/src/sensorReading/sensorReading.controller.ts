import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { SensorReadingService } from "./sensorReading.service";
import { SensorReadingControllerBase } from "./base/sensorReading.controller.base";

@swagger.ApiTags("sensorReadings")
@common.Controller("sensorReadings")
export class SensorReadingController extends SensorReadingControllerBase {
  constructor(protected readonly service: SensorReadingService) {
    super(service);
  }
}
