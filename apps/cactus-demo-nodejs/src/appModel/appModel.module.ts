import { Module } from "@nestjs/common";
import { AppModelModuleBase } from "./base/appModel.module.base";
import { AppModelService } from "./appModel.service";
import { AppModelController } from "./appModel.controller";

@Module({
  imports: [AppModelModuleBase],
  controllers: [AppModelController],
  providers: [AppModelService],
  exports: [AppModelService],
})
export class AppModelModule {}
