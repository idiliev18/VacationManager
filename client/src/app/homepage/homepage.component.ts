import { Component, Inject, OnInit } from '@angular/core';
import { FetchService } from './fetch.service';
import { Team } from './Team';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  employees: Team[] = [];

  header = {
      id: 'Id↑', //↑
      name: 'Name',
      projectsCount: 'Projects Count',
      memebersCount: 'Members Count',
      sort: 'id',
      order: '↑'
  };

  images: string[] = ['https://i.ytimg.com/vi/Rv-oENaktdA/maxresdefault.jpg', 'https://hitmixmusic.bg/wp-content/uploads/2022/02/FB_IMG_1644921812120-750x450.jpg', 'https://www.teamazing.de/wp-content/uploads/2018/10/team.jpg', 'https://www.flagman.bg/news/2021/08/31/tn/163041567047985.jpg'];

  

  public random()
  {
    return Math.floor(Math.random() * (3 - 0 + 0) + 0)
  }
  constructor(private fetchService: FetchService) {}

  sortEmployees(field: string) {

      // Checks if there are elements in the array
      if (this.employees.length == 0) {
          return;
      }

      if (this.header.sort != field) {
          this.header.order = '↓';
      }

      let e = this.employees[0] as any;

      (this.header as any)[this.header.sort] = (this.header as any)[this.header.sort].slice(0, -1);
      this.header.sort = field;

      if (typeof e[field] === 'string') {
          if (this.header.order == '↑') {
              this.employees.sort((a, b) =>
                  (b as any)[field].localeCompare((a as any)[field])
              );

              this.header.order = '↓';
          } else {
              this.employees.sort((a, b) =>
                  (a as any)[field].localeCompare((b as any)[field])
              );

              this.header.order = '↑';
          }
      } else {
          if (this.header.order == '↑') {
              this.employees.sort(
                  (a, b) => (b as any)[field] - (a as any)[field]
              );
              this.header.order = '↓';
          } else {
              this.employees.sort(
                  (a, b) => (a as any)[field] - (b as any)[field]
              );
              this.header.order = '↑';
          }
      }

      (this.header as any)[field] = (this.header as any)[field] + this.header.order;
  }

  ngOnInit(): void {
      this.fetchService.getTeams().subscribe((team) => {
          this.employees = team;
      });
  }
}
