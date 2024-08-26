import * as graphql from "@nestjs/graphql";
import { SensorReadingResolverBase } from "./base/sensorReading.resolver.base";
import { SensorReading } from "./base/SensorReading";
import { SensorReadingService } from "./sensorReading.service";

@graphql.Resolver(() => SensorReading)
export class SensorReadingResolver extends SensorReadingResolverBase {
  constructor(protected readonly service: SensorReadingService) {
    super(service);
  }
}
