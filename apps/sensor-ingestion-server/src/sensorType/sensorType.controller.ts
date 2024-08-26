import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { SensorTypeService } from "./sensorType.service";
import { SensorTypeControllerBase } from "./base/sensorType.controller.base";

@swagger.ApiTags("sensorTypes")
@common.Controller("sensorTypes")
export class SensorTypeController extends SensorTypeControllerBase {
  constructor(protected readonly service: SensorTypeService) {
    super(service);
  }
}
