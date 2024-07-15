import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { SalespersonServiceBase } from "./base/salesperson.service.base";

@Injectable()
export class SalespersonService extends SalespersonServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
