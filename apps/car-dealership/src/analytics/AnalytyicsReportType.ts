import { registerEnumType } from "@nestjs/graphql";

export enum AnalytyicsReportType {
    YearlyReport = "yearlyReport",
    MonthlyReport = "monthlyReport",
    FinanceReport = "financeReport"
}

registerEnumType(AnalytyicsReportType, {
    name: "AnalytyicsReportType",
  });