using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using KFCTrello;
using KFCTrello.Models;
using Xunit;
using Action = KFCTrello.Models.Action;

namespace TrelloTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var serviceAdapter = new KFCServiceAdapter();
            var webhook = TestWebhookCreator();
            var storageModel = serviceAdapter.CreateStorageSaveModel(webhook);
            var testStorageModel = StorageSaveModelCreator();
            Assert.Equal(testStorageModel, storageModel, new Comparer());
        }

        private WebhookModel TestWebhookCreator()
        {
            return new WebhookModel()
            {
                Action = new Action()
                {
                    Data = new Data()
                    {
                        Board = new Board()
                        {
                            Id = "IdBoard",
                            Name = "NameBoard"
                        },
                        Card = new Card()
                        {
                            Id = "IdCard",
                            IdShort = 2,
                            Name = "NameCard"
                        },
                        Voted = true
                    },
                    Date = DateTime.MinValue,
                    Id = "IdAction",
                    IdMemberCreator = "ActionCreator",
                    MemberCreator = new MemberCreator()
                    {
                        Id = "IdMember",
                        AvatarHash = "AvatarHash",
                        FullName = "FullName",
                        Initials = "init",
                        Username = "UserName"
                    },
                    Type = "Card"
                }
            };
        }

        private StorageSaveModel StorageSaveModelCreator()
        {
            return new StorageSaveModel()
            {
                Id = "IdAction",
                Name = "NameBoard",
                Description = "IdBoard",
                Status = "Ok",
                CreatorId = "ActionCreator",
                DeveloperId = "FullName",
                Labels = new[] { "I", "want", "to", "sleep" },
                ProjectId = "IdAction",
                RelatedIssue = new[]
                {
                    new RelatedIssue()
                    {
                        IssueId = "IdCard",
                        ConnectionType = "NameCard"
                    }
                },
                CreationDate = DateTime.MinValue,
                UpdatedDate = DateTime.MinValue
            };
        }

        class Comparer : IEqualityComparer<StorageSaveModel>
        {
            public bool Equals(StorageSaveModel x, StorageSaveModel y)
            {
                var result = true;
                result = result && DiteTimeComparer(x.CreationDate, y.CreationDate);
                result = result && DiteTimeComparer(x.CreationDate, y.CreationDate);
                result = result && DiteTimeComparer(x.UpdatedDate, y.UpdatedDate);

                result = result && StringComparer(x.Id, y.Id);
                result = result && StringComparer(x.Description, y.Description);
                result = result && StringComparer(x.DeveloperId, y.DeveloperId);
                result = result && StringComparer(x.Name, y.Name);
                result = result && StringComparer(x.Status, y.Status);
                result = result && StringComparer(x.CreatorId, y.CreatorId);

                return result;
            }

            private bool StringComparer(string id1, string id2)
            {
                var result = true;
                if (id1 == null && id2 == null)
                    result = result && true;
                else if (id1 != null && id2 != null)
                    result = result && (id1 == id2);
                else return false;
                return result;
            }

            private bool DiteTimeComparer(DateTime date1, DateTime date2)
            {
                var result = true;
                if (date1 == null && date2 == null)
                    result = result && true;
                else if (date1 != null && date2 != null)
                    result = result && (date1 == date2);
                else return false;
                return result;
            }

            public int GetHashCode(StorageSaveModel obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
