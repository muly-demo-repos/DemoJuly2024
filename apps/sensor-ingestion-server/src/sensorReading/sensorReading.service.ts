import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { SensorReadingServiceBase } from "./base/sensorReading.service.base";

@Injectable()
export class SensorReadingService extends SensorReadingServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
