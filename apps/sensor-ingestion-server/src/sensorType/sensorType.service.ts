import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { SensorTypeServiceBase } from "./base/sensorType.service.base";

@Injectable()
export class SensorTypeService extends SensorTypeServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
