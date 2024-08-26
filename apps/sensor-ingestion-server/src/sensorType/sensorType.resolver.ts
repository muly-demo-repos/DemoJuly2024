import * as graphql from "@nestjs/graphql";
import { SensorTypeResolverBase } from "./base/sensorType.resolver.base";
import { SensorType } from "./base/SensorType";
import { SensorTypeService } from "./sensorType.service";

@graphql.Resolver(() => SensorType)
export class SensorTypeResolver extends SensorTypeResolverBase {
  constructor(protected readonly service: SensorTypeService) {
    super(service);
  }
}
