import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { YuvalServiceBase } from "./base/yuval.service.base";

@Injectable()
export class YuvalService extends YuvalServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
