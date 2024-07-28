import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { YuvalModuleBase } from "./base/yuval.module.base";
import { YuvalService } from "./yuval.service";
import { YuvalController } from "./yuval.controller";
import { YuvalResolver } from "./yuval.resolver";

@Module({
  imports: [YuvalModuleBase, forwardRef(() => AuthModule)],
  controllers: [YuvalController],
  providers: [YuvalService, YuvalResolver],
  exports: [YuvalService],
})
export class YuvalModule {}
