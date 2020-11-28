import { CricketApplicationWebPortalTemplatePage } from './app.po';

describe('CricketApplicationWebPortal App', function() {
  let page: CricketApplicationWebPortalTemplatePage;

  beforeEach(() => {
    page = new CricketApplicationWebPortalTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
