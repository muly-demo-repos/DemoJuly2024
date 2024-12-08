import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { CarModuleBase } from "./base/car.module.base";
import { CarService } from "./car.service";
import { CarController } from "./car.controller";
import { CarResolver } from "./car.resolver";

@Module({
  imports: [CarModuleBase, forwardRef(() => AuthModule)],
  controllers: [CarController],
  providers: [CarService, CarResolver],
  exports: [CarService],
})
export class CarModule {}
