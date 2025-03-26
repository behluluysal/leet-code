#ifndef LISTNODE_H
#define LISTNODE_H

#include <vector>
#include <tuple>

struct ListNode {
    int val;
    ListNode* next;
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode* next) : val(x), next(next) {}
};

// Helper functions for testing
ListNode* createLinkedList(const std::vector<int>& values);
std::vector<int> linkedListToVector(ListNode* head);
void deleteLinkedList(ListNode* head);
ListNode* reverseList(ListNode* head);

// Actual Methods
// https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list
ListNode* deleteMiddle(ListNode* head);

// https://leetcode.com/problems/odd-even-linked-list
ListNode* oddEvenList(ListNode* head);

#pragma region [ RoadMap ]

// https://leetcode.com/problems/linked-list-cycle
bool hasCycle(ListNode* head);

// https://leetcode.com/problems/reorder-list
void reorderList(ListNode* head);

// https://leetcode.com/problems/remove-nth-node-from-end-of-list
ListNode* removeNthFromEnd(ListNode* head, int n);

// https://leetcode.com/problems/add-two-numbers
ListNode* addTwoNumbers(ListNode* l1, ListNode* l2);

// https://leetcode.com/problems/find-the-duplicate-number
int findDuplicate(std::vector<int>& nums);

// https://leetcode.com/problems/merge-k-sorted-lists
ListNode* mergeKLists(std::vector<ListNode*>& lists);

// https://neetcode.io/problems/reverse-nodes-in-k-group
ListNode* reverseKGroup(ListNode* head, int k);
std::tuple<ListNode*, ListNode*> reverseListGroup(ListNode* head, int k);

#pragma endregion


#endif // LISTNODE_H