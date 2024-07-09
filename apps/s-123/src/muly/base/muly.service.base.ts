/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { PrismaService } from "../../prisma/prisma.service";
import { Prisma, Muly as PrismaMuly } from "@prisma/client";
import { MyDto } from "../MyDto";
import { MyOtherDto } from "../MyOtherDto";

export class MulyServiceBase {
  constructor(protected readonly prisma: PrismaService) {}

  async count(args: Omit<Prisma.MulyCountArgs, "select">): Promise<number> {
    return this.prisma.muly.count(args);
  }

  async mulies(args: Prisma.MulyFindManyArgs): Promise<PrismaMuly[]> {
    return this.prisma.muly.findMany(args);
  }
  async muly(args: Prisma.MulyFindUniqueArgs): Promise<PrismaMuly | null> {
    return this.prisma.muly.findUnique(args);
  }
  async createMuly(args: Prisma.MulyCreateArgs): Promise<PrismaMuly> {
    return this.prisma.muly.create(args);
  }
  async updateMuly(args: Prisma.MulyUpdateArgs): Promise<PrismaMuly> {
    return this.prisma.muly.update(args);
  }
  async deleteMuly(args: Prisma.MulyDeleteArgs): Promise<PrismaMuly> {
    return this.prisma.muly.delete(args);
  }
  async MyCustomAction(args: MyDto): Promise<MyOtherDto> {
    throw new Error("Not implemented");
  }
}
