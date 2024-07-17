import { Module } from "@nestjs/common";
import { ImpersonationModuleBase } from "./base/impersonation.module.base";
import { ImpersonationService } from "./impersonation.service";
import { ImpersonationController } from "./impersonation.controller";

@Module({
  imports: [ImpersonationModuleBase],
  controllers: [ImpersonationController],
  providers: [ImpersonationService],
  exports: [ImpersonationService],
})
export class ImpersonationModule {}
